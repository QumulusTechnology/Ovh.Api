using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ovh.Api.Models;

public class TaskInfo
{
    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("doneDate")]
    public DateTimeOffset? DoneDate { get; set; }

    [JsonPropertyName("function")]
    public required TaskFunction Function { get; set; }

    [JsonPropertyName("lastUpdate")]
    public DateTimeOffset? LastUpdate { get; set; }

    [JsonPropertyName("needSchedule")]
    public bool? NeedSchedule { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("plannedInterventionId")]
    public int? PlannedInterventionId { get; set; }

    [JsonPropertyName("startDate")]
    public required DateTimeOffset StartDate { get; set; }

    [JsonPropertyName("status")]
    public required TaskStatus Status { get; set; }

    [JsonPropertyName("tags")]
    public List<TaskTag>? Tags { get; set; }

    [JsonPropertyName("taskId")]
    public required uint TaskId { get; set; }

    [JsonPropertyName("ticketReference")]
    public string? TicketReference { get; set; }
}