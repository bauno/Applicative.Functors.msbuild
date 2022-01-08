module Applicative.Functors.Processor

open Chessie.ErrorHandling
open Applicative.Functors.Data
open Applicative.Functors.Core

//validate dto
let validateDto dto =
    validateName dto.Name
//    >>= validateEmail dto.EMail
//    |> function
//        | Ok _ -> ok dto
//        | Bad es -> fail es.Head

//create customer

// process customer

// save into db