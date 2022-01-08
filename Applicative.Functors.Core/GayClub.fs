module Applicative.Functors.GayClub

open Applicative.Functors.Club_Data
open Applicative.Functors.Club_Validation
open Chessie.ErrorHandling

let costToEnter p =
    trial {
        let! result::_ =  
            [checkGender; checkAge; checkClothes; checkSobriety] 
            |> List.map(fun f -> f p)
            |> collect
        return 
            match result.Gender with
            | Female -> 0m
            | Male -> 7.5m
    }