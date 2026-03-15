using Feedback.model;

namespace Feedback.service;

public interface IFeedbackService
{
    Task<List<VOC>> GetAllVOCsAsync(int? teacherId = null, int? studentId = null, CancellationToken ct = default);
    Task<VOC?> GetVOCByIdAsync(int id, CancellationToken ct = default);
    Task<int> CreateVOCAsync(VOC item, CancellationToken ct = default);
    Task<bool> UpdateVOCAsync(int id, VOC item, CancellationToken ct = default);
    Task<bool> DeleteVOCAsync(int id, CancellationToken ct = default);

    Task<List<Listening>> GetAllListeningsAsync(int? teacherId = null, int? studentId = null, CancellationToken ct = default);
    Task<Listening?> GetListeningByIdAsync(int id, bool includeDetails = false, CancellationToken ct = default);
    Task<int> CreateListeningAsync(Listening item, CancellationToken ct = default);
    Task<bool> UpdateListeningAsync(int id, Listening item, CancellationToken ct = default);
    Task<bool> DeleteListeningAsync(int id, CancellationToken ct = default);

    Task<List<ListeningSentenceDetail>> GetAllListeningSentenceDetailsAsync(int? listeningId = null, CancellationToken ct = default);
    Task<ListeningSentenceDetail?> GetListeningSentenceDetailByIdAsync(int id, CancellationToken ct = default);
    Task<int> CreateListeningSentenceDetailAsync(ListeningSentenceDetail item, CancellationToken ct = default);
    Task<bool> UpdateListeningSentenceDetailAsync(int id, ListeningSentenceDetail item, CancellationToken ct = default);
    Task<bool> DeleteListeningSentenceDetailAsync(int id, CancellationToken ct = default);
}
