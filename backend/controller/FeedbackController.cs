using Microsoft.AspNetCore.Mvc;
using Feedback.service;
using Feedback.model;

namespace Feedback.controller;

[ApiController]
[Route("api")]
public class FeedbackController : ControllerBase
{
    private readonly IFeedbackService _svc;

    public FeedbackController(IFeedbackService svc)
    {
        _svc = svc;
    }

    [HttpGet("voc")]
    public async Task<ActionResult<List<VOC>>> ListVOC([FromQuery] int? teacherId, [FromQuery] int? studentId, CancellationToken ct = default)
    {
        var list = await _svc.GetAllVOCsAsync(teacherId, studentId, ct);
        return Ok(list);
    }

    [HttpGet("voc/{id:int}")]
    public async Task<ActionResult<VOC>> GetVOC(int id, CancellationToken ct = default)
    {
        var item = await _svc.GetVOCByIdAsync(id, ct);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost("voc")]
    public async Task<ActionResult<int>> CreateVOC(VOC model, CancellationToken ct = default)
    {
        var id = await _svc.CreateVOCAsync(model, ct);
        return CreatedAtAction(nameof(GetVOC), new { id }, id);
    }

    [HttpPut("voc/{id:int}")]
    public async Task<ActionResult> UpdateVOC(int id, VOC model, CancellationToken ct = default)
    {
        var ok = await _svc.UpdateVOCAsync(id, model, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("voc/{id:int}")]
    public async Task<ActionResult> DeleteVOC(int id, CancellationToken ct = default)
    {
        var ok = await _svc.DeleteVOCAsync(id, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpGet("listening")]
    public async Task<ActionResult<List<Listening>>> ListListening([FromQuery] int? teacherId, [FromQuery] int? studentId, CancellationToken ct = default)
    {
        var list = await _svc.GetAllListeningsAsync(teacherId, studentId, ct);
        return Ok(list);
    }

    [HttpGet("listening/{id:int}")]
    public async Task<ActionResult<Listening>> GetListening(int id, [FromQuery] bool includeDetails = false, CancellationToken ct = default)
    {
        var item = await _svc.GetListeningByIdAsync(id, includeDetails, ct);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost("listening")]
    public async Task<ActionResult<int>> CreateListening(Listening model, CancellationToken ct = default)
    {
        var id = await _svc.CreateListeningAsync(model, ct);
        return CreatedAtAction(nameof(GetListening), new { id }, id);
    }

    [HttpPut("listening/{id:int}")]
    public async Task<ActionResult> UpdateListening(int id, Listening model, CancellationToken ct = default)
    {
        var ok = await _svc.UpdateListeningAsync(id, model, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("listening/{id:int}")]
    public async Task<ActionResult> DeleteListening(int id, CancellationToken ct = default)
    {
        var ok = await _svc.DeleteListeningAsync(id, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpGet("listening-sentence-detail")]
    public async Task<ActionResult<List<ListeningSentenceDetail>>> ListListeningSentenceDetail([FromQuery] int? listeningId, CancellationToken ct = default)
    {
        var list = await _svc.GetAllListeningSentenceDetailsAsync(listeningId, ct);
        return Ok(list);
    }

    [HttpGet("listening-sentence-detail/{id:int}")]
    public async Task<ActionResult<ListeningSentenceDetail>> GetListeningSentenceDetail(int id, CancellationToken ct = default)
    {
        var item = await _svc.GetListeningSentenceDetailByIdAsync(id, ct);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost("listening-sentence-detail")]
    public async Task<ActionResult<int>> CreateListeningSentenceDetail(ListeningSentenceDetail model, CancellationToken ct = default)
    {
        var id = await _svc.CreateListeningSentenceDetailAsync(model, ct);
        return CreatedAtAction(nameof(GetListeningSentenceDetail), new { id }, id);
    }

    [HttpPut("listening-sentence-detail/{id:int}")]
    public async Task<ActionResult> UpdateListeningSentenceDetail(int id, ListeningSentenceDetail model, CancellationToken ct = default)
    {
        var ok = await _svc.UpdateListeningSentenceDetailAsync(id, model, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("listening-sentence-detail/{id:int}")]
    public async Task<ActionResult> DeleteListeningSentenceDetail(int id, CancellationToken ct = default)
    {
        var ok = await _svc.DeleteListeningSentenceDetailAsync(id, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpGet("reading")]
    public async Task<ActionResult<List<Reading>>> ListReading([FromQuery] int? teacherId, [FromQuery] int? studentId, CancellationToken ct = default)
    {
        var list = await _svc.GetAllReadingsAsync(teacherId, studentId, ct);
        return Ok(list);
    }

    [HttpGet("reading/{id:int}")]
    public async Task<ActionResult<Reading>> GetReading(int id, [FromQuery] bool includeDetails = false, CancellationToken ct = default)
    {
        var item = await _svc.GetReadingByIdAsync(id, includeDetails, ct);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost("reading")]
    public async Task<ActionResult<int>> CreateReading(Reading model, CancellationToken ct = default)
    {
        var id = await _svc.CreateReadingAsync(model, ct);
        return CreatedAtAction(nameof(GetReading), new { id }, id);
    }

    [HttpPut("reading/{id:int}")]
    public async Task<ActionResult> UpdateReading(int id, Reading model, CancellationToken ct = default)
    {
        var ok = await _svc.UpdateReadingAsync(id, model, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("reading/{id:int}")]
    public async Task<ActionResult> DeleteReading(int id, CancellationToken ct = default)
    {
        var ok = await _svc.DeleteReadingAsync(id, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpGet("reading-sentence-detail")]
    public async Task<ActionResult<List<ReadingSentenceDetail>>> ListReadingSentenceDetail([FromQuery] int? readingId, CancellationToken ct = default)
    {
        var list = await _svc.GetAllReadingSentenceDetailsAsync(readingId, ct);
        return Ok(list);
    }

    [HttpGet("reading-sentence-detail/{id:int}")]
    public async Task<ActionResult<ReadingSentenceDetail>> GetReadingSentenceDetail(int id, CancellationToken ct = default)
    {
        var item = await _svc.GetReadingSentenceDetailByIdAsync(id, ct);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost("reading-sentence-detail")]
    public async Task<ActionResult<int>> CreateReadingSentenceDetail(ReadingSentenceDetail model, CancellationToken ct = default)
    {
        var id = await _svc.CreateReadingSentenceDetailAsync(model, ct);
        return CreatedAtAction(nameof(GetReadingSentenceDetail), new { id }, id);
    }

    [HttpPut("reading-sentence-detail/{id:int}")]
    public async Task<ActionResult> UpdateReadingSentenceDetail(int id, ReadingSentenceDetail model, CancellationToken ct = default)
    {
        var ok = await _svc.UpdateReadingSentenceDetailAsync(id, model, ct);
        if (!ok) return NotFound();
        return NoContent();
    }

    [HttpDelete("reading-sentence-detail/{id:int}")]
    public async Task<ActionResult> DeleteReadingSentenceDetail(int id, CancellationToken ct = default)
    {
        var ok = await _svc.DeleteReadingSentenceDetailAsync(id, ct);
        if (!ok) return NotFound();
        return NoContent();
    }
}
