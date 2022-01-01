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

    let customer = { Id = 42; Name = "John"; Email = "john@example.com" }

    validate customer
    >>= update
    >>= send
    |> should equal (Bad [ "update error" ])

[<Fact>]
let ``bind should create valid customer if no failures``() = 
    let validate c = ok c
    let update c = ok c
    let send c = ok c

    let customer = { Id = 42; Name = "John"; Email = "john@example.com" }

    validate customer
    >>= update
    >>= send
    |> should equal (ok { Id = 42; Name = "John"; Email = "john@example.com" })    
