module Applicative.Functors.Club_Validation

open Chessie.ErrorHandling
open Applicative.Functors.Club_Data

let checkAge p = 
    if p.Age < 18 then fail "Too young!"
    elif p.Age > 40 then fail "Too old!"
    else ok p

let checkClothes person = 
    if person.Gender = Male && not (person.Clothes.Contains "Tie") then fail "Smarten up!"
    elif person.Gender = Female && person.Clothes.Contains "Trainers" then fail "Wear high heels"
    else ok person

let checkSobriety person = 
    match person.Sobriety with
    | Drunk | Paralytic | Unconscious -> fail "Sober up!"
    | _ -> ok person

let checkGender person =
    if person.Gender = Male then ok person
    else fail "Men Only"

let checkTicket person = 
    if person.HasTicket then ok person
    else fail "You have to buy a ticket!"
