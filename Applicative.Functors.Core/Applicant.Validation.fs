module Applicative.Functors.Applicant_Validation

open Chessie.ErrorHandling
open Applicative.Functors.Applicant

let checkApplicant request =
  checkAge request
  >>= checkFirstName
  >>= checkLastName
 
let recheckApplicant request =
    disallowPink request
    >>= checkApplicant
  
let processRequest request = 
  match checkApplicant request with
  | Pass  _       ->  printfn "All Good!!!"
  | Warn (_,log)  ->  printfn "Got some issues:"
                      for msg in log do printfn " %s" msg
  | _             ->  printfn "Something went horribly wrong."

let reportMessages request =
  match recheckApplicant request with
  | Pass  _       ->  printfn "Nothing to report"
  | Warn (_,log)  ->  printfn "Got some issues:"
                      for msg in log do printfn $"{msg}"
  | Fail  errors  ->  printfn "Got errors:"
                      for msg in errors do printfn $"{msg}"