module Applicative.Functors.Tests.Club_Tests

open Applicative.Functors.Club_Data
open Applicative.Functors
open FsUnit.Xunit
open Xunit
open Chessie.ErrorHandling

let Ken = { Person.Gender = Male; Age = 28; Clothes = set ["Tie"; "Shirt"]; Sobriety = Tipsy; HasTicket = true }
let Dave = { Person.Gender = Male; Age = 41; Clothes = set ["Tie"; "Jeans"]; Sobriety = Sober; HasTicket = true }
let Ruby = { Person.Gender = Female; Age = 25; Clothes = set ["High heels"]; Sobriety = Tipsy; HasTicket = true }

let Tom = { Person.Gender = Male; Age = 59; Clothes = set ["Jeans"]; Sobriety = Paralytic; HasTicket = false }

let ``Tom's son`` = { Person.Gender = Male; Age = 12; Clothes = set ["Jeans"]; Sobriety = Sober; HasTicket = false }

[<Fact>]
let ``A paralytic cannot enter a gay bar`` () =
     let expected =  Bad ["Too old!"; "Smarten up!"; "Sober up!"; "You have to buy a ticket!" ] : Result<decimal, string>
     
     Tom
     |> GayClub.costToEnter
     |> should equal expected

[<Fact>]
let ``Ken can be clubbed to death`` () =
     Ken
     |> ClubDeath.costToEnter
     |> should equal (ok<decimal, string>(5m))

[<Fact>]
let ``Dave is too old to enter`` () =
     Dave
     |> ClubDeath.costToEnter
     |> should equal (fail<decimal, string> "Too old!")

[<Fact>]
let ``Dave is too old to enter a gay club`` () =
     Dave
     |> GayClub.costToEnter
     |> should equal (fail<decimal, string> "Too old!")

[<Fact>]
let ``Ruby can enter for free`` () =
     Ruby
     |> ClubDeath.costToEnter
     |> should equal (ok<decimal, string> 0m)
     
[<Fact>]
let ``Young Ruby cannot enter`` () =
     { Ruby with Age=17 }
     |> ClubDeath.costToEnter
     |> should equal (fail<decimal, string> "Too young!")

[<Fact>]
let ``what about tom's son?``() =
     ``Tom's son``
     |> GayClub.costToEnter
     |> should equal (Bad ["Too young!"; "Smarten up!"; "You have to buy a ticket!"] : Result<decimal, string>)