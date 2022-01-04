module Applicative.Functors.Tests.ProcessorTests
open Applicative.Functors.Data
open Applicative.Functors.Processor
open FsUnit.Xunit
open Xunit
open Chessie.ErrorHandling
open Applicative.Functors.TestConvenience

[<Fact>]
let ``Can validate dto`` () =
    let dto = {Name = "pippo"; EMail = "pippo@pippo.com"}
       
    dto |> validateDto |> succ |> should equal {Name = "pippo"; EMail = "pippo@pippo.com"}
    
[<Fact>]  
let ``dto with empty name is invalid`` () =
     let dto = {Name = ""; EMail = "pippo@pippo.com"}
     
     let res =  dto |> validateDto
     
     res |> err |> should equal ["invalid name"]
   