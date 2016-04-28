module Core

open FSharp.Data
open Newtonsoft.Json
open System.IO
open System.Text.RegularExpressions
open NCrafts.App.Business.Common.JsonSerializer.Data

let sessionUrl = "http://ncrafts.io/api/sessions.json"
type Sessions = JsonProvider<"http://ncrafts.io/api/sessions.json">

let speakerUrl = "http://ncrafts.io/api/speakers.json"
type Speakers = JsonProvider<"http://ncrafts.io/api/speakers.json">
type FindSpeaker = string -> Speakers.Root option

let save path json = File.WriteAllText (path, json)

let mapSession (findSpeaker:FindSpeaker) (session:Sessions.Root) =
    let mapped = new SessionModelTmp()
    mapped.Details             <- session.Abstract
    mapped.DurationInMinutes    <- session.DurationMinutes
    mapped.Id                   <- session.Id
//    mapped.Place                <- session.??
    mapped.Tags                 <- session.Tags
    mapped.Title                <- session.Title
//    mapped.Type                 <- session.??
    mapped.SpeakersId <- new ResizeArray<string>(match (findSpeaker session.Id) with | Some x  -> [x.Id] | _ -> [])
    mapped.StartTime <- match session.StartTime with | Some date -> date.ToString() | None -> null
    mapped

let mapSpeakerSession (findSpeaker:FindSpeaker) (session:Speakers.Session) = 
    let mapped = new SessionModelTmp()
    mapped.Details             <- session.Abstract
    mapped.DurationInMinutes   <- session.DurationMinutes
    mapped.Id                   <- session.Id
//    mapped.Place                <- session.??
    mapped.SpeakersId <- new ResizeArray<string>(match (findSpeaker session.Id) with | Some x  -> [x.Id] | _ -> [])
    mapped.StartTime <- match session.StartTime with | Some date -> date.ToString() | None -> null
    mapped.Tags                 <- session.Tags
    mapped.Title                <- session.Title
//    mapped.Type                 <- session.??
    mapped

let mapGithub rawGithub = 
    let (|Name|ApiPage|None|) (input:string) =
        let name = Regex.Match(input, @"^([0-9a-zA-Z]+)$") 
        let accountPage = Regex.Match(input, @"^https:\/\/github.com\/([0-9a-zA-Z]+)$")
        let apiPage =  Regex.Match(input, @"^https:\/\/api.github.com\/user\/(\d+)$") 
        
        if (name.Success)               then Name (string name.Groups.[1])
        else if (accountPage.Success)   then Name (string accountPage.Groups.[1])
        else if (apiPage.Success)       then ApiPage (string apiPage.Groups.[1])
        else None

    let getGithubLogin = function
        | "216452" -> "Morendil"
        | "351773" -> "jak78"
        | id -> 
            printfn "%s" id
            failwith "Unknown github id, please go to https://api.github.com/users/" + id

    match rawGithub with
    | Some (Name name) -> name
    | Some (ApiPage id) -> getGithubLogin id
    | _ -> null
    

let mapSpeaker  (findSpeaker:FindSpeaker) (speaker:Speakers.Root) =
    let mapped = new SpeakerModelTmp()
    mapped.Avatar           <- new AvatarModelTmp()
    mapped.Avatar.IconBig   <- speaker.Photo
    mapped.Avatar.IconSmall <- speaker.Photo
//    mapped.Books        <- speaker.??
    mapped.Company      <- match speaker.Company with | Some x -> x | None -> null
    mapped.Id           <- speaker.Id
    mapped.Github       <- mapGithub speaker.Github 
    mapped.Details      <- speaker.Bio
    mapped.Languages    <- new ResizeArray<string>(speaker.Languages.Strings)
    mapped.FirstName    <- speaker.FirstName 
    mapped.LastName     <- speaker.LastName
    mapped.SessionsId   <- new ResizeArray<string>(speaker.Sessions |> Seq.map (mapSpeakerSession findSpeaker) |> Seq.map (fun x -> x.Id))
    mapped.Site         <- match speaker.Site with | Some x -> x | None -> null 
//    mapped.Slides       <- speaker.??
    mapped.Twitter      <- speaker.Twitter
    mapped

let findSpeaker (speakers:Speakers.Root[]) (sessionId:string) =
    let isSpeakerSession (speaker:Speakers.Root) = speaker.Sessions |> Seq.exists (fun x -> x.Id = sessionId)
    speakers |> Seq.tryFind isSpeakerSession

let extractSessions findSpeaker =
    Sessions.Load(sessionUrl)
    |> Seq.map (mapSession findSpeaker)
    |> JsonConvert.SerializeObject
    |> save "sessions.json"

let extractSpeakers findSpeaker =
    Speakers.Load(speakerUrl)
    |> Seq.map (mapSpeaker findSpeaker)
    |> JsonConvert.SerializeObject
    |> save "speakers.json"

let extractData() =
    let sessions = Sessions.Load(sessionUrl)
    let speakers = Speakers.Load(speakerUrl)
    let findSpeaker' = findSpeaker speakers
    extractSessions findSpeaker'
    extractSpeakers findSpeaker'
