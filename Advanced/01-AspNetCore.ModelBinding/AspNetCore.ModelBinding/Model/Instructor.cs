﻿using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.ModelBinding;

// <snippet_Class>
public class Instructor
{
    public int Id { get; set; }

    [FromQuery(Name = "Note")]
    public string? NoteFromQueryString { get; set; }

    // ...
}
// </snippet_Class>
