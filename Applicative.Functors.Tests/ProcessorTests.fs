module Applicative.Functors.Tests.ProcessorTests
open Applicative.Functors.Data
open Applicative.Functors.Processor
open FsUnit.Xunit
open Xunit
open Applicative.Functors.TestConvenience

[<Fact>]
let ``Can validate dto`` () =
    let dto = {Name = "pippo"; EMail = "pippo@pippo.com"}
       
    dto |> validateDto |> succ |> should equal {Name = "pippo"; EMail = "pippo@pippo.com"}
    
[<Fact>]  
let ``dto with empty name is invalid`` () =
     let dto = { Name = ""; EMail = "pippo@pippo.com" }
     dto |> validateDto |> err |> should equal ["name '' is too short"]

[<Theory>]
[<InlineData("pippo@pippo.com", true)>]
[<InlineData("pippo@pluto", false)>]
[<InlineData("", false)>]
let ``Can check if email is valid`` (email: string) (expected: bool) =
    let dto = { Name = "pippo"; EMail = email }
    let actual = dto |> validateDto
    match expected with
    | true -> succ actual |> should equal dto
    | false -> err actual |> should equal [$"email '{email}' is not valid"]