fun exeVolume(comprimento: Double, largura: Double, altura: Double): Double {
    return comprimento * largura * altura
}

fun main() {
    print("Informe o comprimento da caixa: ")
    val comprimento = readLine()?.toDoubleOrNull()

    print("Informe a largura da caixa: ")
    val largura = readLine()?.toDoubleOrNull()

    print("Informe a altura da caixa: ")
    val altura = readLine()?.toDoubleOrNull()

    if (comprimento == null || largura == null || altura == null) {
        println("Entrada inválida. Certifique-se de digitar valores numéricos corretos.")
        return
    }

    val volume = exeVolume(comprimento, largura, altura)
    println("O volume da caixa é: %.2f unidades cúbicas".format(volume))
}
