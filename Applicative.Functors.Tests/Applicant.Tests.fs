module Applicative.Functors.Tests.Applicant_Tests

open System
open Applicative.Functors.Applicant_Validation
open Applicative.Functors.Applicant
open FsUnit.Xunit
open Xunit
open Chessie.ErrorHandling

[<Fact>]
let ``Bad applicant`` () =
     let applicant = { FullName      = "John","Smith" 
                       DateOfBirth   = DateTime (1995,12,21)
                       FavoriteColor = Some Color.Pink }
     applicant |> recheckApplicant |> should equal (fail<Applicant, string> "Get outta here with that color!")
     
[<Fact>]     
let ``Applicant with warnings`` () =
    let applicant =  { FullName      = "","Smith" 
                       DateOfBirth   = DateTime (1995,12,21)
                       FavoriteColor = Some Color.Green}
    applicant |> recheckApplicant |> should equal (warn<Applicant, string> "First name is missing" applicant)

[<Fact>]
let ``terminal failure``() =
    let applicant = { FullName      = "Bob","Smith" 
                      DateOfBirth   = DateTime (1995,12,21)
                      FavoriteColor = Some Color.Green}
    applicant |> recheckApplicant |> should equal (ok<Applicant, string> applicant)