# EvcilHayvanTakipSistemi

Proje Adı ve Amaç

Proje Adı: Evcil Hayvan Takip Sistemi

Proje Amacı : Evcil hayvanlaıın bilgilerinin kaydedilebileceği ve veteriner randevularını alıp bu randevuları takip edebilecekleri bir konsol uygulamasıdır.

Projenin Genel Tanımı

Kullanıcı geri dönüşlü bir programdır.

Kullanılan Teknolojiler

C# yazılım dili kullanılmıştır. System; ve System.Collections.Generic; kütüphaneleri kullanılmıştır. .Net Framework kullanılmıştır.

Gereksinimler ve Kurulum

İşlemci 1 GHz RAM 512 MB Minimum disk alanı 2 mb

Kullanım Senaryoları

Kullanıcı klavye ile sistemle etkileşime girer.

Kullancıı girişi istenir. Yanlış bilgi girildiğinde tekrardan sorar.

Kullanıcı giriş yapar ve ana sayfaya yönlendirilir.

1 Evcil Hayvan Ekle 2 Evcil Hayvan Bilgileri Görüntüle 3 Randevular 4 Randevu göster 5 Çıkış Kullanıcıdan seçimleri yapması istenir. Seçim "1" de Ad,Tür,Renk ve Doğum Tarihi bilgileri istenir.

Seçim "2" de Evcil hayvanın adı sorulur ve bilgileri gösterilir. Kayıtlı evcil hayvan yoksa ya da daha önce girilmemişse bunu hata olarak belirtir.

Seçim "3" de Uygun bir tarihte veteriner randevusu oluşturulur ve randevu için "açıklama" istenir. Eğer geçmiş bir tarih girilirse randevu verilmez.

Seçim "4" de Var olan tüm evcil hayvanlar için bir randevu varsa gösterilir yoksa olmadığı belirtilir.

Seçim "5" de Sistemden çıkar.

Sorunlar ve Çözümler

"Evcil Hayvan Bilgileri Görüntüle" kısmında kullanıcının kaydettiği randevuları göstermek istedik. Sistem randevuları kaydettikten sonra "Evcil Hayvan Bilgileri Görüntüle" randevu bilgisini liste içinden çekmesi gerekiyordu, ama "Evcil Hayvan Bilgileri Görüntüle" ksımı listeye erişemiyordu çözüm olarak randevu görüntelemeyi ayrı bir bölüm olarak kullanıcıya "Randevu görüntüle" olarak sunduk.
