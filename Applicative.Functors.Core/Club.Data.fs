module Applicative.Functors.Club_Data

type Sobriety = 
    | Sober
    | Tipsy
    | Drunk
    | Paralytic
    | Unconscious

type Genders = 
    | Male
    | Female

type Person = 
    { Gender : Genders
      Age : int
      Clothes : string Set
      Sobriety : Sobriety }