#include <stdio.h>
#include <stdlib.h>
#include <string.h>


typedef struct {
    char model[50];
    char marka[50];
    char seriNo[20];
    int koltukKapasitesi;
} Ucak;


typedef struct {
    char ulke[50];
    char sehir[50];
    char havaalani[50];
    int aktif;
} Lokasyon;


typedef struct {
    Lokasyon kalkis;
    Lokasyon varis;
    char saat[10];
    Ucak ucakBilgisi;
} Ucus;


typedef struct {
    Ucus ucus;
    char ad[50];
    char soyad[50];
    int yas;
} Rezervasyon;


void ucakListele(Ucak *ucaklar, int ucakSayisi);
void lokasyonEkle(Lokasyon *lokasyonlar, int *lokasyonSayisi);
void ucusEkle(Ucus *ucuslar, int *ucusSayisi, Ucak *ucaklar, int ucakSayisi, Lokasyon *lokasyonlar, int lokasyonSayisi);
void rezervasyonYap(Rezervasyon *rezervasyonlar, int *rezervasyonSayisi, Ucus *ucuslar, int ucusSayisi);
void dosyayaKaydet(Ucak *ucaklar, int ucakSayisi, Lokasyon *lokasyonlar, int lokasyonSayisi, Ucus *ucuslar, int ucusSayisi, Rezervasyon *rezervasyonlar, int rezervasyonSayisi);

int main() {
    Ucak ucaklar[10];
    Lokasyon lokasyonlar[10];
    Ucus ucuslar[10];
    Rezervasyon rezervasyonlar[50];

    int ucakSayisi = 0;
    int lokasyonSayisi = 0;
    int ucusSayisi = 0;
    int rezervasyonSayisi = 0;

    // Örnek Uçaklar
    strcpy(ucaklar[ucakSayisi].model, "Boeing 737");
    strcpy(ucaklar[ucakSayisi].marka, "Boeing");
    strcpy(ucaklar[ucakSayisi].seriNo, "SN123");
    ucaklar[ucakSayisi].koltukKapasitesi = 150;
    ucakSayisi++;

    strcpy(ucaklar[ucakSayisi].model, "Airbus A320");
    strcpy(ucaklar[ucakSayisi].marka, "Airbus");
    strcpy(ucaklar[ucakSayisi].seriNo, "SN456");
    ucaklar[ucakSayisi].koltukKapasitesi = 180;
    ucakSayisi++;

    // Örnek Lokasyonlar
    strcpy(lokasyonlar[lokasyonSayisi].ulke, "Turkiye");
    strcpy(lokasyonlar[lokasyonSayisi].sehir, "Ankara");
    strcpy(lokasyonlar[lokasyonSayisi].havaalani, "ANK");
    lokasyonlar[lokasyonSayisi].aktif = 1;
    lokasyonSayisi++;

    strcpy(lokasyonlar[lokasyonSayisi].ulke, "Turkiye");
    strcpy(lokasyonlar[lokasyonSayisi].sehir, "İstanbul");
    strcpy(lokasyonlar[lokasyonSayisi].havaalani, "SAW");
    lokasyonlar[lokasyonSayisi].aktif = 1;
    lokasyonSayisi++;

    int secim;

    do {
        printf("\n1. Ucak Listele");
        printf("\n2. Lokasyon Ekle");
        printf("\n3. Ucus Ekle");
        printf("\n4. Rezervasyon Yap");
        printf("\n5. Cikis\n");

        printf("\nSeciminizi yapiniz: ");
        scanf("%d", &secim);

        switch (secim) {
            case 1:
                ucakListele(ucaklar, ucakSayisi);
                break;
            case 2:
                lokasyonEkle(lokasyonlar, &lokasyonSayisi);
                break;
            case 3:
                ucusEkle(ucuslar, &ucusSayisi, ucaklar, ucakSayisi, lokasyonlar, lokasyonSayisi);
                break;
            case 4:
                rezervasyonYap(rezervasyonlar, &rezervasyonSayisi, ucuslar, ucusSayisi);
                break;
            case 5:
                dosyayaKaydet(ucaklar, ucakSayisi, lokasyonlar, lokasyonSayisi, ucuslar, ucusSayisi, rezervasyonlar, rezervasyonSayisi);
                printf("Programdan cikiliyor.\n");
                break;
            default:
                printf("Gecersiz secim! Lutfen tekrar deneyin.\n");
        }
    } while (secim != 5);

    return 0;
}

void ucakListele(Ucak *ucaklar, int ucakSayisi) {
    printf("\n--- Ucak Listesi ---\n");
    for (int i = 0; i < ucakSayisi; i++) {
        printf("Model: %s, Marka: %s, Seri No: %s, Koltuk Kapasitesi: %d\n",
               ucaklar[i].model, ucaklar[i].marka, ucaklar[i].seriNo, ucaklar[i].koltukKapasitesi);
    }
}

void lokasyonEkle(Lokasyon *lokasyonlar, int *lokasyonSayisi) {
    if (*lokasyonSayisi < 10) {
        printf("\nUlke: ");
        scanf("%s", lokasyonlar[*lokasyonSayisi].ulke); 

        /
        printf("Sehir: ");
        scanf("%s", lokasyonlar[*lokasyonSayisi].sehir);

        printf("Havaalani: ");
        scanf("%s", lokasyonlar[*lokasyonSayisi].havaalani);

        lokasyonlar[*lokasyonSayisi].aktif = 1;  

        (*lokasyonSayisi)++;
        printf("Lokasyon eklendi.\n");
    } else {
        printf("Maksimum lokasyon sayisina ulasildi.\n");
    }
}

void rezervasyonYap(Rezervasyon *rezervasyonlar, int *rezervasyonSayisi, Ucus *ucuslar, int ucusSayisi) {
    if (*rezervasyonSayisi < 50) {
        printf("\n--- Ucus Listesi ---\n");
        ucakListele(ucuslar, ucusSayisi);

        int secilenUcus;
        printf("Rezervasyon yapmak istediginiz ucusun numarasini giriniz: ");
        scanf("%d", &secilenUcus);

        if (secilenUcus >= 0 && secilenUcus < ucusSayisi) {
            if (ucuslar[secilenUcus].ucus.ucakBilgisi.koltukKapasitesi > 0) {
                printf("Ad: ");
                scanf("%s", rezervasyonlar[*rezervasyonSayisi].ad);

                printf("Soyad: ");
                scanf("%s", rezervasyonlar[*rezervasyonSayisi].soyad);

                printf("Yas: ");
                scanf("%d", &rezervasyonlar[*rezervasyonSayisi].yas);

                rezervasyonlar[*rezervasyonSayisi].ucus = ucuslar[secilenUcus].ucus;
                (*rezervasyonSayisi)++;

                
                ucuslar[secilenUcus].ucus.ucakBilgisi.koltukKapasitesi--;

                printf("Rezervasyon basariyla yapildi.\n");
            } else {
                printf("Ucak dolu. Rezervasyon yapilamaz.\n");
            }
        } else {
            printf("Gecersiz ucus numarasi.\n");
        }
    } else {
        printf("Maksimum rezervasyon sayisina ulasildi.\n");
    }
}

void dosyayaKaydet(Ucak *ucaklar, int ucakSayisi, Lokasyon *lokasyonlar, int lokasyonSayisi, Ucus *ucuslar, int ucusSayisi, Rezervasyon *rezervasyonlar, int rezervasyonSayisi) {
    FILE *dosya = fopen("rezervasyonlar.txt", "w");
    if (dosya == NULL) {
        printf("Dosya acilamadi.\n");
        return;
    }

    
    fprintf(dosya, "--- Ucaklar ---\n");
    for (int i = 0; i < ucakSayisi; i++) {
        fprintf(dosya, "Model: %s, Marka: %s, Seri No: %s, Koltuk Kapasitesi: %d\n",
                ucaklar[i].model, ucaklar[i].marka, ucaklar[i].seriNo, ucaklar[i].koltukKapasitesi);
    }

   
    fprintf(dosya, "\n--- Lokasyonlar ---\n");
    for (int i = 0; i < lokasyonSayisi; i++) {
        fprintf(dosya, "Ulke: %s, Sehir: %s, Havaalani: %s, Aktif: %d\n",
                lokasyonlar[i].ulke, lokasyonlar[i].sehir, lokasyonlar[i].havaalani, lokasyonlar[i].aktif);
    }

    
    fprintf(dosya, "\n--- Ucuslar ---\n");
    for (int i = 0; i < ucusSayisi; i++) {
        fprintf(dosya, "Kalkis: %s - %s, Varis: %s - %s, Saat: %s\n",
                ucuslar[i].kalkis.ulke, ucuslar[i].kalkis.sehir, ucuslar[i].varis.ulke, ucuslar[i].varis.sehir, ucuslar[i].saat);
    }

    
    fprintf(dosya, "\n--- Rezervasyonlar ---\n");
    for (int i = 0; i < rezervasyonSayisi; i++) {
        fprintf(dosya, "Ad: %s, Soyad: %s, Yas: %d, Ucus: %s - %s\n",
                rezervasyonlar[i].ad, rezervasyonlar[i].soyad, rezervasyonlar[i].yas,
                rezervasyonlar[i].ucus.kalkis.ulke, rezervasyonlar[i].ucus.kalkis.sehir);
   

void dosyayaKaydet(Ucak *ucaklar, int ucakSayisi, Lokasyon *lokasyonlar, int lokasyonSayisi, Ucus *ucuslar, int ucusSayisi, Rezervasyon *rezervasyonlar, int rezervasyonSayisi) {
    FILE *dosya = fopen("rezervasyonlar.txt", "w");
    if (dosya == NULL) {
        printf("Dosya acilamadi.\n");
        return;
    }

    
    fprintf(dosya, "--- Ucaklar ---\n");
    for (int i = 0; i < ucakSayisi; i++) {
        fprintf(dosya, "Model: %s, Marka: %s, Seri No: %s, Koltuk Kapasitesi: %d\n",
                ucaklar[i].model, ucaklar[i].marka, ucaklar[i].seriNo, ucaklar[i].koltukKapasitesi);
    }

   
    fprintf(dosya, "\n--- Lokasyonlar ---\n");
    for (int i = 0; i < lokasyonSayisi; i++) {
        fprintf(dosya, "Ulke: %s, Sehir: %s, Havaalani: %s, Aktif: %d\n",
                lokasyonlar[i].ulke, lokasyonlar[i].sehir, lokasyonlar[i].havaalani, lokasyonlar[i].aktif);
    }

    
    fprintf(dosya, "\n--- Ucuslar ---\n");
    for (int i = 0; i < ucusSayisi; i++) {
        fprintf(dosya, "Kalkis: %s - %s, Varis: %s - %s, Saat: %s\n",
                ucuslar[i].kalkis.ulke, ucuslar[i].kalkis.sehir, ucuslar[i].varis.ulke, ucuslar[i].varis.sehir, ucuslar[i].saat);
    }

    
    fprintf(dosya, "\n--- Rezervasyonlar ---\n");
    for (int i = 0; i < rezervasyonSayisi; i++) {
        fprintf(dosya, "Ad: %s, Soyad: %s, Yas: %d, Ucus: %s - %s\n",
                rezervasyonlar[i].ad, rezervasyonlar[i].soyad, rezervasyonlar[i].yas,
                rezervasyonlar[i].ucus.kalkis.ulke, rezervasyonlar[i].ucus.kalkis.sehir);
    }

    
    fclose(dosya);
}
    int main() {
    

    do {
        

    } while (secim != 5);

    dosyayaKaydet(ucaklar, ucakSayisi, lokasyonlar, lokasyonSayisi, ucuslar, ucusSayisi, rezervasyonlar, rezervasyonSayisi);

    return 0;
}

