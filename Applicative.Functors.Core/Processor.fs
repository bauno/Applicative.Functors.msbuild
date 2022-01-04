module Applicative.Functors.Processor

open Chessie.ErrorHandling
open Applicative.Functors.Data

//validate dto
let validateDto dto =
    if dto.Name.Length <> 0
    then 
        ok dto
    else
        fail "invalid name"

//create customer

// process customer

// save into db