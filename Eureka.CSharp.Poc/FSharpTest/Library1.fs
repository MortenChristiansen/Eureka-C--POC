namespace FSharpTest

open ServiceStack.ServiceInterface
open ServiceStack.Common
open ServiceStack.ServiceHost

[<CLIMutable>]
type Company = { mutable Id:string; mutable Name:string }

[<Route("/companies", "POST")>]
type CreateCompany() =
    interface IReturn<Company>
    member val Id = "" with get, set
    member val Name = "" with get, set

[<Route("/companies", "PUT")>]
type UpdateCompany() =
    interface IReturn<Company>
    member val Id = "" with get, set
    member val Name = "" with get, set

type CompaniesService() =
    inherit Service()

    member this.Post (request:CreateCompany) : Company =
        let company = request.TranslateTo<Company>()
        company

    member this.Put (request:UpdateCompany) : Company =
        let company = { Id = "id"; Name = "Company" }
        company.PopulateWith(request) |> ignore
        company