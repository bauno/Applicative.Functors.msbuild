module Applicative.Functors.Applicant

open System
open Chessie.ErrorHandling

type Color = Red | White | Black | Pink | Green

type Applicant = 
  { FullName      :string * string
    DateOfBirth   :DateTime
    FavoriteColor :Color option }

let checkName getName msg request =
  let name = getName request
  if String.IsNullOrWhiteSpace name
    then  // note the invalid datum, but stay on the _passing_ track
          request |> warn msg
    else  // no issues, proceed on the "happy path"
          request |> pass

let checkFirstName  = checkName (fun {FullName = (name,_)} -> name) "First name is missing"
let checkLastName   = checkName (fun {FullName = (_,name)} -> name) "Last name is missing"

let checkAge request =
  let dob   = request.DateOfBirth
  let diff  = DateTime.Today.Subtract dob
  if  diff  < TimeSpan.FromDays (18.0 * 365.0)
    then  // note the invalid datum, but stay on the _passing_ track
          request |> warn "DateOfBirth is too recent"
    else  // no issues, proceed on the "happy path"
          request |> pass
  
let disallowPink request =
    match request.FavoriteColor with
    | Some c // no idea why we're being mean to this particular color
        when c = Color.Pink -> fail "Get outta here with that color!"
    | _                     -> pass request
    
