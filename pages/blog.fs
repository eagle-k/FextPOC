module Blog

open Fable.Core
open Feliz

let Blog() =
    Html.h1 "Hello, Fext!"

JsInterop.exportDefault Blog
