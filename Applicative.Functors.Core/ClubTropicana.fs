module Applicative.Functors.ClubTropicana

open Applicative.Functors.Club_Validation
open Applicative.Functors.Club_Data
open Chessie.ErrorHandling

let costToEnter p =
    trial {
        let! a = checkAge p
        let! b = checkClothes a
        let! c = checkSobriety b
        return 
            match c.Gender with
            | Female -> 0m
            | Male -> 5m
    }