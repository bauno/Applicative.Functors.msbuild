module Applicative.Functors.GayClub

open Applicative.Functors.Club_Data
open Applicative.Functors.Club_Validation
open Chessie.ErrorHandling

let costToEnter person =
    trial {
        let! result::_ =  
            [checkGender; checkAge; checkClothes; checkSobriety] 
            |> List.map(fun validate -> validate person)
            |> collect
            
        return 
            match result.Gender with
            | Female -> 0m
            | Male -> 7.5m
    }