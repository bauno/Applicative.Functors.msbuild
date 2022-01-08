module Applicative.Functors.Tests.Core

open Xunit
open FsUnit.Xunit

[<Fact>]
let ``I can pass the first dumb test`` () =
    true |> should be True

[<Fact>]
let ``I can pass the second dumb test`` () =
    1 + 1 |> should equal  2