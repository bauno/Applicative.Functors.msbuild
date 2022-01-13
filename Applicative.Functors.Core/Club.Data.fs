module Applicative.Functors.Club_Data

type Sobriety = 
    | Sober
    | Tipsy
    | Drunk
    | Paralytic
    | Unconscious

type Gender = 
    | Male
    | Female

type Person = {
      Gender : Gender
      Age : int
      Clothes : string Set
      Sobriety : Sobriety 
      HasTicket: bool
      }