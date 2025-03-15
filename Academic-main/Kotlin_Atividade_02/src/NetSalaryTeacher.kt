fun exeNetSalaryTeacher(horasTrabalhadas: Double, valorHoraAula: Double, percentualDesconto: Double): Double {
    val salarioBruto = horasTrabalhadas * valorHoraAula
    val desconto = salarioBruto * (percentualDesconto / 100)
    val salarioLiquido = salarioBruto - desconto

    println("Salário Bruto: R$ %.2f".format(salarioBruto))
    println("Desconto INSS: R$ %.2f".format(desconto))
    println("Salário Líquido: R$ %.2f".format(salarioLiquido))

    return salarioLiquido
}

fun main() {
    print("Informe o número de horas trabalhadas no mês: ")
    val horasTrabalhadas = readLine()?.toDoubleOrNull()

    print("Informe o valor da hora-aula: ")
    val valorHoraAula = readLine()?.toDoubleOrNull()

    print("Informe o percentual de desconto do INSS: ")
    val percentualDesconto = readLine()?.toDoubleOrNull()

    if (horasTrabalhadas == null || valorHoraAula == null || percentualDesconto == null) {
        println("Entrada inválida. Certifique-se de digitar valores numéricos corretos.")
        return
    }

    exeNetSalaryTeacher(horasTrabalhadas, valorHoraAula, percentualDesconto)
}
