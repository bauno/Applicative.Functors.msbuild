module Applicative.Functors.Data

type Customer =
    {
        Id: int
        Name: string
        EMail: string
    }
    
type CustomerDto = {
        Name: string
        EMail: string
}