fun quebraLinha() {
    print("Digite uma frase: ")
    val frase = readLine()!!
    print("Digite a quantidade de colunas: ")
    val colunas = readLine()!!.toInt()
    println(quebrarLinha(frase, colunas))
}

fun quebrarLinha(frase: String, colunas: Int): String {
    val palavras = frase.split(" ")
    val resultado = StringBuilder()
    var linhaAtual = ""

    for (palavra in palavras) {
        if ((linhaAtual + palavra).length > colunas) {
            resultado.append(linhaAtual.trim()).append("\n")
            linhaAtual = ""
        }
        linhaAtual += "$palavra "
    }
    resultado.append(linhaAtual.trim())
    return resultado.toString()
}