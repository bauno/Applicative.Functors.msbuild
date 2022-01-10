module Applicative.Functors.Tests.ProcessorTests
open Applicative.Functors.Data
open Applicative.Functors.Processor
open FsUnit.Xunit
open Xunit
open Chessie.ErrorHandling

[<Fact>]
let ``Can validate dto`` () =   
    {Name = "pippo"; EMail = "pippo@pippo.com"}
    |> validateDto
    |> should equal (ok<CustomerDto, string> {Name = "pippo"; EMail = "pippo@pippo.com"})
    
[<Fact>]  
let ``dto with empty name is invalid`` () =
     { Name = ""; EMail = "pippo@pippo.com" }
     |> validateDto
     |> should equal (fail<CustomerDto, string> "name '' is too short")

[<Theory>]
[<InlineData("pippo@pippo.com", true)>]
[<InlineData("pippo@pluto", false)>]
[<InlineData("", false)>]
let ``Can check if email is valid`` (email: string) (expected: bool) =
    let dto = { Name = "pippo"; EMail = email }
    let actual = dto |> validateDto
    match expected with
    | true -> actual |> should equal (ok<CustomerDto,string> dto)
    | false -> actual |> should equal (fail<CustomerDto, string>($"email '{email}' is not valid"))