Repositori ini merupakan kode sumber dari penelitian **Implementasi Sentiment Analysis Menggunakan Accord.NET dan Naive Bayes Classifier** yang dilombakan pada kegiatan Piala MIPA Universitas Pakuan 2018.

# Emotex

Emotex merupakan aplikasi untuk melakukan sentiment analysis menggunakan Naive Bayes Classifier dan library Accord.NET.

Aplikasi ini bersifat open-source dan dilisensikan di bawah MIT License.

## Training dan Evaluasi

Data set yang digunakan untuk training berasal dari repositori ML.NET yang berjumlah 2000 sentimen. Data set di bagi dua dan setengahnya digunakan untuk *training* dan setengahnya lagi untuk *evaluation*.

    Accuracy: 66,30%
    Sensitivity: 60,40%
    F1-score: 64,19%
    AUC: 6,30%

## Asbtrak

Karya ilmiah dengan judul Emotex: Implementasi Sentiment Analysis menggunakan Accord.NET dan Naive Bayes Classifier ini ditulis selain untuk mengikuti perlombaan Piala MIPA 2018, karya ilmiah ini juga ditulis untuk menguraikan bagaimana cara membuat aplikasi untuk melakukan analisis sentimen menggunakan Accord.NET dan naive bayes classifier.

Teknik analisis data yang digunakan adalah Teknik Deskriptif Kuantitatif. Setelah data dikumpulkan, selanjutnya adalah training dan evaluation. Setelah proses testing, dapat diketahui berbagai faktor dari hasil training menggunakan confusion matrix dan ROC curve.

Naive bayes merupakan supervised learning dan metode statistika yang digunakan untuk melakukan klasifikasi. Implementasi naive bayes classifier ini terdapat pada library Accord.NET yang dapat digunakan pada bahasa pemprograman berbasis .NET.

Model yang dibuat menggunakan naive bayes dengan jumlah training data sebanyak 1000 sentimen memberikan akurasi sebesar 66,30%. Hasil tersebut didapatkan setelah data mentah diolah menggunakan tokenizer, penghilangan stop words, dan stemming.

Kata Kunci: Sentiment Analysis, Naive Bayes, Bag of Words

# Referensi

[1] Asian, J., Williams, H. E., & Tahaghoghi, S. M. (2005). Stemming Indonesian. Conferences in Research and Practice in Information Technology Series, 38, 307–314. doi:10.1145/1316457.1316459

[2] Kohavi, R., & Provost, F. (1998). Special Issue on Applications of Machine Learning and the Knowledge Discovery Process. Diambil kembali dari Stanford Artificial Intellegence Library.

[3] Kumar, R., & Indrayan, A. (2011, April 17). Receiver Operating Characteristic (ROC) Curve for Medical Researchers. 48, 277.

[4] McCarthy, J. (1989). Artificial Intelligence, Logic and Formalizing Common Sense. Philosophical Logic and Artificial Intelligence.

[5] Mihaescu, C. (2010, May 7). Naive-Bayes Classification Algorithm. Diambil kembali dari University of Craiova.

[6] Porter, M. F. (2001). Snowball: A language for stemming algorithms.

[7] Souza, C., Cross, A., Gustafsson, A., Catalano, M. D., Voss, S., Zavvari, H., . . . Stefan. (2017, October). The Accord.NET Framework. (Version v3.8.0). Zenodo. doi:10.5281/zenodo.1029481