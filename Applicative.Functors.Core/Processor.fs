module Applicative.Functors.Processor

open Chessie.ErrorHandling
open Applicative.Functors.Data
open Applicative.Functors.Core

//validate dto
let validateDto dto =
    validateDtoName dto
    >>= validateDtoEmail
    
//create customer

// process customer

// save into db