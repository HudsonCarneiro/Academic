//JSX
function welcome(){
    return <h1>Hello World!</h1>;
}
//COMPONENTES E PROPS
//Componente funcional
function Mensagem(props) {
    return <h1>Olá, {props.nome}!</h1>
}
//Uso
<Mensagem nome="João" />

//Componentes de classe
class Mensagem extends React.Component {
    render() {
        return <h1>Olá, {this.props.nome}!</h1>
    }
}

//ESTADO E CICLO DE VIDA 
//Estado com Hook 
import { useState } from "react";
function Contador(){
    const [contagem, setContagem] = useState(0);
    return (
        <div>
            <p>Contagem: {contagem} </p>
            <button onClick={() => setContagem(contagem + 1 )}>Incrementar</button>
        </div>
    )
}
