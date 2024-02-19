using Core.Persistence.Dynamic;
using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Exam : Entity<Guid>
{
    public Guid ClassRoomTypeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int QuestionCount { get; set; }
    public string QuestionType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ClassRoomType ClassRoomType { get; set; }
    public ICollection<Question> Questions { get; set; }
}

// Sınav sonucu classı eklenmeli Mi?
// - Sınav puanı
// - Doğru Sayısı
// - yanlış sayısı
// - boş sayısı

//---------------------------------------

// Kullanıcının cevabını alalım
// UserAnswer userAnswer = GetUserAnswer(); // Örnek bir fonksiyon çağrısı

// Doğru cevabı alalım
// Choice correctChoice = GetCorrectChoiceForQuestion(userAnswer.QuestionId); // Örnek bir fonksiyon çağrısı

// Kullanıcının cevabını kontrol edelim
// bool isCorrect = (userAnswer.ChoiceId == correctChoice.Id);








/* Soru
 *   Id
 *   Metin
 *   Doğru cevap
 *   Şıklar   ICollection<şık> şıklar gibi...
 */

/* Soru tablosu:
  *  Id 
  *  metni
  *  
  *  şıklar metni  
  *  IsCorrect      doğru şık, true
 */

/* Şıklar tablosu:
 *  Id
 *  soru Id
 *  şık metni
 *  doğru şık
 */

/* Kullanıcı sınav tablosu:
 *  kullanıcı Id, sınav Id, soru Id
 *  kullanıcı sınavları
 *  verilen cevaplar
 *  
 */

//Soru Tablosu
//ExamId, metin ,A, B, C, D, True(Doğru Cevap)

//StudentQuestion
//QuestionId, studentId, Verilen Cevap, Doğruluğu
