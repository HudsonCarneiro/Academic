/*
Crie um programa que recebe um texto e encontra a primeira letra não repetida.
Caso não exista, imprima que não existem letras que não se repetem no texto
informado.

 */
fun letrasRepetidas(){
    println("Digite um texto: ")
    val texto = readLine()!!
    val letra = primeiraLetraNaoRepetida(texto)
    if (letra != null) {
        println("A primeira letra não repetida é: $letra")
    } else {
        println("Não há letras não repetidas.")
    }
}
fun primeiraLetraNaoRepetida(texto: String): Char? {
    val frequencia = texto.groupingBy { it }.eachCount()
    return texto.firstOrNull { frequencia[it] == 1 }
}