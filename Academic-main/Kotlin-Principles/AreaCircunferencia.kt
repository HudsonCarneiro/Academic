fun areaCircunferencia() {
    println("Digite o raio da circunferência: ")
    val raio = readLine()?.toDoubleOrNull()
    val pi = 3.14159265;

    if (raio != null && raio > 0) {
        val area = pi * raio * raio
        println("A área da circunferência é: %.2f".format(area))
    } else {
        println("Valor inválido! O raio deve ser um número positivo.")
    }
}
