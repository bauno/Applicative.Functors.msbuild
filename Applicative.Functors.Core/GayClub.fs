module Applicative.Functors.GayClub

open Applicative.Functors.Club_Data
open Applicative.Functors.Club_Validation
open Chessie.ErrorHandling

let private costToEnter' checks  person =
    
    trial {
        let! result::_ =  
            checks
            |> List.map(fun check -> check person)
            |> collect
            
        return 
            match result.Gender with
            | Female -> 0m
            | Male -> 7.5m
    }

let costToEnter person =
    let checks = [checkGender; checkAge; checkClothes; checkSobriety; checkTicket] 
    costToEnter' checks person
