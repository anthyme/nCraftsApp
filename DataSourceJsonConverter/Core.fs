module Core

open FSharp.Data
open Newtonsoft.Json
open System.IO
open NCrafts.App.Business.Common.JsonSerializer.Data

let sessionUrl = "http://ncrafts.io/api/sessions.json"
type Sessions = JsonProvider<"http://ncrafts.io/api/sessions.json">

let speakerUrl = "http://ncrafts.io/api/speakers.json"
type Speakers = JsonProvider<"http://ncrafts.io/api/speakers.json">
type FindSpeaker = string -> Speakers.Root option

let save path json = File.WriteAllText (path, json)

let mapSession (findSpeaker:FindSpeaker) (session:Sessions.Root) =
    let mapped = new SessionModel()
    mapped.Abstract             <- session.Abstract
    mapped.DurationInMinutes    <- session.DurationMinutes
    mapped.EventId              <- session.Event
    mapped.Id                   <- session.Id
//    mapped.Place                <- session.??
    mapped.Tags                 <- session.Tags
    mapped.Title                <- session.Title
//    mapped.Type                 <- session.??
    let speaker = match findSpeaker session.Id with | Some x -> x.Id, x.FirstName + " " + x.LastName | None -> "anonymous", "anonymous"
    mapped.SpeakerId <- fst speaker
    mapped.SpeakerName <- snd speaker
    mapped.StartTime <- match session.StartTime with | Some date -> date.ToString() | None -> null

    mapped

let mapSpeakerSession (findSpeaker:FindSpeaker) (session:Speakers.Session) = 
    let mapped = new SessionModel()
    mapped.Abstract             <- session.Abstract
    mapped.DurationInMinutes    <- session.DurationMinutes
    mapped.EventId              <- session.Event
    mapped.Id                   <- session.Id
//    mapped.Place                <- session.??
    let speaker = match findSpeaker session.Id with | Some x -> x.Id, x.FirstName + " " + x.LastName | None -> "anonymous", "anonymous"
    mapped.SpeakerId <- fst speaker
    mapped.SpeakerName <- snd speaker
    mapped.StartTime <- match session.StartTime with | Some date -> date.ToString() | None -> null
    mapped.Tags                 <- session.Tags
    mapped.Title                <- session.Title
//    mapped.Type                 <- session.??
    mapped

let mapSpeaker  (findSpeaker:FindSpeaker) (speaker:Speakers.Root) =
    let mapped = new SpeakerModel()
    mapped.Avatar <- new AvatarModel()
    mapped.Avatar.Url <- speaker.Photo
//    mapped.Books        <- speaker.??
    mapped.Company      <- match speaker.Company with | Some x -> x | None -> null
    mapped.Id           <- speaker.Id
    mapped.Github       <- match speaker.Github with | Some x -> x | None -> null
    
    mapped.Languages    <- new ResizeArray<string>(speaker.Languages.Strings)
    
    mapped.Name         <- speaker.FirstName + " " + speaker.LastName
    mapped.Sessions     <- new ResizeArray<SessionModel>(speaker.Sessions |> Seq.map (mapSpeakerSession findSpeaker))
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
