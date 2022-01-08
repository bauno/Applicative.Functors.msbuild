module Applicative.Functors.Club_Validation

open Chessie.ErrorHandling
open Applicative.Functors.Club_Data

let checkAge (p : Person) = 
    if p.Age < 18 then fail "Too young!"
    elif p.Age > 40 then fail "Too old!"
    else ok p

let checkClothes (p : Person) = 
    if p.Gender = Male && not (p.Clothes.Contains "Tie") then fail "Smarten up!"
    elif p.Gender = Female && p.Clothes.Contains "Trainers" then fail "Wear high heels"
    else ok p

let checkSobriety (p : Person) = 
    match p.Sobriety with
    | Drunk | Paralytic | Unconscious -> fail "Sober up!"
    | _ -> ok p

let checkGender (p : Person) = 
    if p.Gender = Male then ok p 
    else fail "Men Only"