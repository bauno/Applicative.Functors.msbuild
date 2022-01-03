module Applicative.Functors.Tests.Customer

open FsUnit.Xunit
open Chessie.ErrorHandling
open Xunit
open Applicative.Functors.Data

[<Fact>]
let ``bind should bypass after first error``() = 
    let validate c = ok c
    let update c = fail "update error"
    let send c = fail "send error"

    let customer = { Id = 42; Name = "John"; EMail = "john@example.com" }

    validate customer
    >>= update
    >>= send
    |> should equal (Bad [ "update error" ])

[<Fact>]
let ``bind should create valid customer if no failures``() = 
    let validate n dto  = ok dto
    let update i c  = ok c
    let send c = ok c

    let customer = { Id = 42; Name = "John"; EMail = "john@example.com" }
    
    let create dto = ok customer

    validate "pippo" 3
    >>= create
    >>= update 4
    >>= send
    |> should equal (ok { Id = 42; Name = "John"; EMail = "john@example.com" })    
