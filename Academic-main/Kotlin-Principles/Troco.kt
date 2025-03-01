/*
Funcionários de empresas comerciais que trabalham como caixa têm uma grande
responsabilidade em suas mãos. A maioria do tempo de seu expediente de
trabalho é gasto recebendo valores de clientes e, em alguns casos, fornecendo
troco. Crie um programa que leia o valor total a ser pago e o valor efetivamente
pago, informando o menor número de cédulas e moedas que devem ser fornecidas
como troco. Deve-se considerar que há:
➢ cédulas de R$100,00, R$50,00, R$10,00, R$5,00 e R$1,00;
➢ moedas de R$0,50, R$0,10, R$0,05 e R$0,01.

 */
fun troco() {
    print("Digite o valor total a ser pago: ")
    val valorTotal = readLine()!!.toDouble()
    print("Digite o valor pago: ")
    val valorPago = readLine()!!.toDouble()
    calcularTroco(valorPago, valorTotal)
}

fun calcularTroco(valorPago: Double, valorTotal: Double) {
    var troco = (valorPago - valorTotal).toBigDecimal().setScale(2).toDouble()
    val cedulasMoedas = listOf(100.0, 50.0, 10.0, 5.0, 1.0, 0.50, 0.10, 0.05, 0.01)

    println("Troco: R$%.2f".format(troco))
    for (valor in cedulasMoedas) {
        val quantidade = (troco / valor).toInt()
        if (quantidade > 0) {
            println("$quantidade x R$%.2f".format(valor))
            troco -= quantidade * valor
        }
    }
}