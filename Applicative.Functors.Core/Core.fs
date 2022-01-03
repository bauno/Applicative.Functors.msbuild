module Applicative.Functors.Core

open Chessie.ErrorHandling
open System.Text.RegularExpressions

open Applicative.Functors.Data

let validateId id = if id > 0 then ok id else fail $"Invalid Id: '{id}'"

let validateName (name: string) = if name.Length > 2 then ok name else fail $"name '{name}' is too short"

let validateEmail (email: string) = 
    let regex = Regex @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"
    match regex.IsMatch(email) with
    | true -> ok email
    | false -> fail $"email '{email}' is not valid"
    

let createCustomer id name email =
    let create = fun i n e -> {Id = i; Name = n; EMail = e}

    create
    <!> validateId id
    <*> validateName name
    <*> validateEmail email

let bindCreateCustomer id name email =
    let create = fun id name email -> { Id = id; Name = name; EMail = email }
    
    validateId id 
    >>= fun _ -> validateName name
    >>= fun _ -> validateEmail email
    >>= fun _ -> ok (create id name email)