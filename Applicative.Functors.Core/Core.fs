module Applicative.Functors.Core

open Chessie.ErrorHandling
open System.Text.RegularExpressions

open Applicative.Functors.Data

let validateId id = if id > 0 then ok id else fail (printf "Invalid Id: {id}")

let validateName (name: string) = if name.Length > 2 then ok name else fail "name too short"

let validateEmail (email: string) = 
    let regex = Regex @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"
    match regex.IsMatch(email) with
    | true -> ok email
    | false -> fail "email not valid"
    

let createCustomer id name email =
    let create = fun i n e -> {Id = i; Name = n; Email = e}

    create
    <!> validateId id
    <*> validateName name
    <*> validateEmail email
