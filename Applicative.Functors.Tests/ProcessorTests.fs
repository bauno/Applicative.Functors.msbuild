module Applicative.Functors.Tests.ProcessorTests
open Applicative.Functors.Data
open Applicative.Functors.Processor
open FsUnit.Xunit
open Xunit
open Chessie.ErrorHandling

[<Fact>]
let ``Can validate dto`` () =
    let dto = {Name = "pippo"; EMail = "pippo@pippo.com"}
    
    dto |> validateDto |> should equal (ok dto)