# 🛡️ LifeSure AI Destekli Sigorta Sistemi 🚀  
.NET MVC 4.7.2 ile Geliştirilen Akıllı Sigorta Platformu  
![.NET MVC](https://img.shields.io/badge/.NET_Framework-4.7.2-blue) ![OpenAI](https://img.shields.io/badge/OpenAI-GPT_3.5_Turbo-ffb400?logo=openai&logoColor=white) ![HuggingFace](https://img.shields.io/badge/Hugging_Face-FLUX.1--dev-yellow?logo=huggingface) ![Language](https://img.shields.io/badge/Languages-Tr%20%2F%20En-green)

---

## 📌 Proje Özeti  

**LifeSure**, yapay zeka destekli SSS (Sıkça Sorulan Sorular) ve dinamik hizmet yönetimi ile zenginleştirilmiş bir **sigorta portalıdır**. Proje, .NET MVC (v4.7.2) mimarisi üzerine kurulmuş, hem yönetici (Admin Panel) hem de kullanıcı (UI) tarafında gelişmiş özellikler sunar.

---

## 🧠 Yapay Zeka Entegrasyonları

### 🤖 1. GPT-3.5 Turbo ile SSS (FAQ) Üretimi  
Admin paneli üzerinden, yalnızca birkaç tıklamayla yapay zekaya yeni sorular ve cevaplar ürettirilebilir.

#### 📋 Akış:

| Aşama | Açıklama |
|------|----------|
| 🖊️ Soru Yazımı | Admin, `1.input` alanına istediği soruyu yazar. |
| 🎯 Soru Oluştur | "Soru Oluştur" butonuna tıklanır. |
| 📤 OpenAI İsteği | GPT-3.5 Turbo modeli ile soruya benzer bir SSS üretilir. |
| 💾 Veritabanı Kaydı | Üretilen soru `QuestionTitle` ve `Question` tablolarına kaydedilir. |
| 💬 Cevap Üretimi | "Cevap Oluştur" butonuna tıklanır, OpenAI cevabı üretir. |
| ✅ Sonuç | Cevap 3. inputa yazılır ve `QuestionAnswer` tablosuna kaydedilir. |



---

### 🧩 2. Hugging Face ile Görsel Üretimli Hizmet Tanımlama  

Yönetici, yeni bir hizmet oluştururken açıklamasını yazdığında HuggingFace API’sine istek atılır. Kullanılan model: **`black-forest-labs/FLUX.1-dev`**

#### 📷 Görsel Üretim Süreci:

- Hizmet Adı ve İkon bilgisi girilir.
- Açıklama kısmına prompt (metinsel açıklama) yazılır.
- Text-to-Image işlemi başlatılır.
- Oluşturulan görsel local dosya sistemine kaydedilir.
- Dosya yolu veritabanına işlenir.

---

## 🌍 UI Tarafı: Kullanıcı Deneyimi  

### 🔄 Çok Dilli Destek
- **Türkçe - İngilizce** dil geçişi sağlanmıştır.
- `@Resources` ve `resx` dosyaları üzerinden lokalizasyon yapılmıştır.

### 📊 LinkedIn API Entegrasyonu

- Sağ üst köşede, ilgili kişinin **LinkedIn takipçi sayısı** gösterilir.
- Veri, **RapidAPI üzerinden LinkedIn Data Scraper API** ile çekilir.

### 🧾 Kullanıcı Yetkileri:

| Rol | Neler Yapar? |
|-----|----------|
| 👑 Yönetici (Admin) | - CRUD İşlemleri<br>- SSS üretme<br>- Hizmet ekleme (Görsel dahil)<br>- AI destekli üretimler |
| 👤 Kullanıcı | - Sigorta bilgilerini görme<br>- SSS listesini inceleme<br>- Hizmet detaylarına erişim |

---

## 🛠️ Kullanılan Teknolojiler  

| Teknoloji | Açıklama |
|----------|---------|
| 💻 .NET MVC 4.7.2 | Backend framework |
| 🧠 OpenAI GPT 3.5 Turbo | SSS üretimi |
| 🎨 Hugging Face FLUX.1-dev | Görsel üretimi |
| 🗃️ MSSQL | Veritabanı sistemi |
| 🌐 RapidAPI (LinkedIn Scraper) | LinkedIn'den takipçi verisi çekme |
| 🌍 i18n (Localization) | Dil desteği (TR / EN) |

---
<img width="1906" height="901" alt="Ekran görüntüsü 2025-07-20 125434" src="https://github.com/user-attachments/assets/cd0b26de-57a1-40bd-9dc3-e99a8e3cb23d" />
<img width="1897" height="898" alt="Ekran görüntüsü 2025-07-20 125349" src="https://github.com/user-attachments/assets/d3495517-b0c8-43dd-b8fe-4f2419b24305" />

<img width="1897" height="899" alt="Ekran görüntüsü 2025-07-20 125446" src="https://github.com/user-attachments/assets/8d64fba4-32ce-43ae-a203-b69651ba1c09" />

<img width="1896" height="904" alt="Ekran görüntüsü 2025-07-20 130041" src="https://github.com/user-attachments/assets/c40f365c-7583-4afd-9088-a997fa641fb5" />
<img width="2546" height="1266" alt="Ekran görüntüsü 2025-07-20 153808" src="https://github.com/user-attachments/assets/f0189fcc-63cf-478a-9cee-0fb2acbbee29" />

<img width="1896" height="722" alt="Ekran görüntüsü 2025-07-20 130340" src="https://github.com/user-attachments/assets/27d97760-6419-4768-80e1-e1447f08d5ea" />
<img width="1897" height="902" alt="Ekran görüntüsü 2025-07-20 130347" src="https://github.com/user-attachments/assets/b03bad40-01cc-4a32-8081-28934ca75bee" />
<img width="1899" height="906" alt="Ekran görüntüsü 2025-07-20 130433" src="https://github.com/user-attachments/assets/873f9ea4-aaa5-411a-9027-31ac3fa49df8" />
<img width="1896" height="908" alt="Ekran görüntüsü 2025-07-20 131341" src="https://github.com/user-attachments/assets/95731c35-14de-44ad-9b5c-c63947de15b7" />
<img width="2549" height="1258" alt="Ekran görüntüsü 2025-07-20 153259" src="https://github.com/user-attachments/assets/f7390096-f767-4fb4-aada-6126cd7aca65" />
<img width="2545" height="1262" alt="Ekran görüntüsü 2025-07-20 153305" src="https://github.com/user-attachments/assets/0bbc05c8-e291-40ac-8b9c-644eb695b96d" />
<img width="2538" height="1256" alt="Ekran görüntüsü 2025-07-20 153323" src="https://github.com/user-attachments/assets/7768cd40-8241-4a90-87e3-4a5c9647be2b" />
<img width="2547" height="1261" alt="Ekran görüntüsü 2025-07-20 153331" src="https://github.com/user-attachments/assets/a558349e-124a-431e-8cf0-3a83a8699e6e" />

<img width="2547" height="1261" alt="Ekran görüntüsü 2025-07-20 153347" src="https://github.com/user-attachments/assets/94c02cbe-9942-4b25-8e06-9c8159901396" />
<img width="2551" height="1258" alt="Ekran görüntüsü 2025-07-20 153336" src="https://github.com/user-attachments/assets/31908e7b-820c-46fc-b08e-e3def4c22ada" />

<img width="2545" height="1266" alt="Ekran görüntüsü 2025-07-20 153352" src="https://github.com/user-attachments/assets/3efc64cc-fd94-467f-9af6-7d172764ede3" />
<img width="2541" height="1257" alt="Ekran görüntüsü 2025-07-20 153358" src="https://github.com/user-attachments/assets/26306fef-33cb-419a-af53-101b1a24ab21" />
<img width="2542" height="1267" alt="Ekran görüntüsü 2025-07-20 153404" src="https://github.com/user-attachments/assets/57fbf72a-7698-4e0c-897b-e834e220c02a" />
<img width="2544" height="1256" alt="Ekran görüntüsü 2025-07-20 153410" src="https://github.com/user-attachments/assets/59205ef8-512b-48a3-9eea-1fa06f5b062a" />
