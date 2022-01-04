module Applicative.Functors.TestConvenience

open Chessie.ErrorHandling

let succ =
        function
            | Ok (res,_) -> res
            | Bad _ -> failwith "not a success"
            
let err =
    function
        | Ok _ -> failwith "not an error"
        | Bad es -> es