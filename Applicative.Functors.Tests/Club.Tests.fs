module Applicative.Functors.Tests.Club_Tests

open Applicative.Functors.Club_Data
open Applicative.Functors
open FsUnit.Xunit
open Xunit
open Chessie.ErrorHandling
open Applicative.Functors.TestConvenience

let Ken = { Person.Gender = Male; Age = 28; Clothes = set ["Tie"; "Shirt"]; Sobriety = Tipsy }
let Dave = { Person.Gender = Male; Age = 41; Clothes = set ["Tie"; "Jeans"]; Sobriety = Sober }
let Ruby = { Person.Gender = Female; Age = 25; Clothes = set ["High heels"]; Sobriety = Tipsy }
let Tom = { Person.Gender = Male; Age = 59; Clothes = set ["Jeans"]; Sobriety = Paralytic }

[<Fact>]
let ``A paralytic cannot enter a gay bar`` () =
     Tom
     |> GayClub.costToEnter
     |> err
     |> should equal ["Too old!"; "Smarten up!"; "Sober up!"]