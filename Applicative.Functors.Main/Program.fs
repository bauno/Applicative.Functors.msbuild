// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open Applicative.Functors.Core

// Define a function to construct a message to print
let from whom =
    whom |> sprintf "from %s"
    

[<EntryPoint>]
let main argv =
    let message = from "il porco Dio" // Call the function
    printfn "\nHello world %s" message
    0 // return an integer exit code