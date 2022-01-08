module Applicative.Functors.ClubDeath

open Chessie.ErrorHandling
open Applicative.Functors.Club_Data
open Applicative.Functors.Club_Validation

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