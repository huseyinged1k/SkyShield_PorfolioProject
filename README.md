# 🛡️ SkyShield - Real Time Basic Air Defense Simulation

**SkyShield**, modüler yapıda geliştirilmiş basit bir hava savunma simülasyon sistemidir. Bu proje, yazılım mimarileri, tasarım desenleri, multimedya işleme ve gerçek zamanlı veri iletimi konularını sergilemek üzere hazırlanmış basit bir projedir.  

Proje iki ana modülden oluşur:

- 🎮 Unity ile geliştirilen **Simülasyon Ortamı**

- 🖥️ C# Windows Forms ile geliştirilen **Gözetim ve Log Arayüzü**

---

├── Air Defense Simulation/         ← Unity (Modül 1) 

├── SkyShieldInterface/      ← Windows Forms (Modül 2)

---

🎮 Unity Simülasyonu

- Füze ve drone tehditlerini rastgele üretir.

- Mesafe ve tehdit türüne göre angajman kararı verir.

- Angajman anında ekran görüntüsü FFmpeg ile kaydedilir (video).

- Not: Kayıt alınırken video gerçek zamanlı izlenemez. Simülasyon sona erdiğinde oluşan .mp4 dosyası oynatılabilir.

- Tüm veriler (zaman, id, tür) UDP üzerinden aktarılır.

---

🖥️ Windows Forms Arayüzü

Unity tarafından gönderilen UDP verilerini dinler.

Tehdit bilgilerini gerçek zamanlı listeler (zaman,id, tür).

Her log log_archive.json dosyasına yazılır.

Savunma atışları sırasında:

🔊 NAudio ile alarm.wav çalınır.

🎥 Video kaydı tamamlandığında gösterilir.

---

| Alan                       | Uygulama / Desen                                  |
| -------------------------- | ------------------------------------------------- |
| **Log Yönetimi**           | 🔁 `Observer Pattern` (LogSubject → ILogObserver) |
| **Katmanlı Yapı**          | 🧱 `Service Layer Pattern`                        |
| **Video Kaydı Yönetimi**   | 🧩 Event-driven mantık, Single Responsibility     |
| **Veri Tabanlı Uyumluluk** | 🔄 Loose Coupling (UDP + JSON temelli iletim)     |
| **Senkronizasyon**         | ⏱ FPS uyumlu frame capture + async akış           |
| **Ses Yönetimi**           | 🧰 `NAudio` ile platformdan bağımsız ses çalma    |

---

🧰 Kullanılan Teknolojiler

🎮 Unity 2022+ (C#)

🖥️ Windows Forms (.NET 8)

📽️ FFmpeg (gömülü video kaydı)

🔊 NAudio (alarm sesleri için)

📡 UDP Socket ile veri iletimi

📄 JSON ile veri formatlama ve kayıt

---

🚀 Kurulum ve Çalıştırma

- Unity projesini "Air Defense Simulation" klasöründen açın.

- ffmpeg.exe dosyasının StreamingAssets klasöründe olduğundan emin olun.

- Unity'den simülasyonu başlatın.

- Aynı anda "SkyShieldInterface" Windows Forms uygulamasını çalıştırın.

- Savunma atışları gerçekleştiğinde:

	Unity FFmpeg ile video kaydeder.

	UDP üzerinden veri aktarımı yapılır.

	Form arayüzü tehditleri listeler ve alarm verir.

---

🎯 Amaç ve Hedefler

Gerçek zamanlı sistem senaryoları kurmak

C# dilinde hem oyun hem de masaüstü uygulama geliştirme becerilerini göstermek

Temiz kodlama, yazılım mimarisi, uygulamalar arası haberleşme ve multimedya entegrasyonunu bir arada sunmak