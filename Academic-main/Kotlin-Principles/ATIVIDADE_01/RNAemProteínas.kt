fun main() {
    print("Digite a sequência de RNA: ")
    val rna = readLine()!!
    println(traduzirRNA(rna).joinToString(", "))
}

fun traduzirRNA(rna: String): List<String> {
    val tabelaCodons = mapOf(
            "AUG" to "Metionina", "UUU" to "Fenilalanina", "UUC" to "Fenilalanina",
            "UUA" to "Leucina", "UUG" to "Leucina", "UCU" to "Serina", "UCC" to "Serina",
            "UCA" to "Serina", "UCG" to "Serina", "UAU" to "Tirosina", "UAC" to "Tirosina",
            "UGU" to "Cisteína", "UGC" to "Cisteína", "UGG" to "Triptofano",
            "UAA" to "STOP", "UAG" to "STOP", "UGA" to "STOP"
    )

    val proteinas = mutableListOf<String>()
    rna.chunked(3).forEach { codon ->
        if (tabelaCodons[codon] == "STOP") return proteinas
        tabelaCodons[codon]?.let { proteinas.add(it) }
    }
    return proteinas
}
