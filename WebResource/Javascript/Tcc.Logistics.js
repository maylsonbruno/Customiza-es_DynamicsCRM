if (typeof (Tcc) == "undefined") { Tcc = {} }
if (typeof (Tcc.Logistics) == "undefined") { Tcc.Logistics = {} }

Tcc.Logistics = {
    ValidaCPF: function (executionContext) {
        debugger;
        var formContext = executionContext.getFormContext();
        var cpf = formContext.getAttribute("tcc_cpf").getValue();

        cpf = cpf.replace(/[^\d]/g, '')
        if (
            !cpf || 
            cpf.length != 11 ||
            cpf == "00000000000" ||
            cpf == "11111111111" ||
            cpf == "22222222222" ||
            cpf == "33333333333" ||
            cpf == "44444444444" ||
            cpf == "55555555555" ||
            cpf == "66666666666" ||
            cpf == "77777777777" ||
            cpf == "88888888888" ||
            cpf == "99999999999"
        ) {
            Tcc.Logistics.DynamicsAlert("CPF Inválido ", " Insira um CPF válido");
            formContext.getAttribute("tcc_cpf").setValue("");
            return false
        }
        var soma = 0
        var resto
        for (var i = 1; i <= 9; i++)
            soma = soma + parseInt(cpf.substring(i - 1, i)) * (11 - i)
        resto = (soma * 10) % 11
        if ((resto == 10) || (resto == 11)) resto = 0
        if (resto != parseInt(cpf.substring(9, 10))) return false
        soma = 0
        for (var i = 1; i <= 10; i++)
            soma = soma + parseInt(cpf.substring(i - 1, i)) * (12 - i)
        resto = (soma * 10) % 11
        if ((resto == 10) || (resto == 11)) resto = 0
        if (resto != parseInt(cpf.substring(10, 11)))
            return false
        return true
    },

    BuscaCep: (executionContext) => {
        debugger;
             const formContext = typeof executionContext.getFormContext === "function" ? executionContext.getFormContext() : executionContext;
        const cep = formContext.getAttribute("address1_postalcode").getValue();
        var parameters = {};
        parameters.cep = cep; 

        var req = new XMLHttpRequest();
        req.open("POST", Xrm.Utility.getGlobalContext().getClientUrl() + "/api/data/v9.2/new_Recuperacep", true);
        req.setRequestHeader("OData-MaxVersion", "4.0");
        req.setRequestHeader("OData-Version", "4.0");
        req.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        req.setRequestHeader("Accept", "application/json");
        req.onreadystatechange = function () {
            if (this.readyState === 4) {
                req.onreadystatechange = null;
                if (this.status === 200 || this.status === 204) {
                    var result = JSON.parse(this.response);
                    console.log(result);
                    var dadoscep = JSON.parse(result["dadosCep"]); 
                    Tcc.Logistics.preencheCamposEndereco(formContext,dadoscep);
                } else {
                    console.log(this.responseText);
                }
            }
        };
        req.send(JSON.stringify(parameters));
      
    },
    preencheCamposEndereco: (formContext, dadosCep) => {
      
        formContext.getAttribute('address1_line1').setValue(dadosCep.logradouro);
        formContext.getAttribute('address1_country').setValue(dadosCep.localidade);
        formContext.getAttribute('address1_stateorprovince').setValue(dadosCep.uf);
        formContext.getAttribute('address1_line3').setValue(dadosCep.bairro);
        formContext.getAttribute('tcc_ibge').setValue(dadosCep.ibge);
        formContext.getAttribute('tcc_ddd').setValue(dadosCep.ddd);
        
    },
    DynamicsAlert: function (alertText, alertTitle) {
            var alertStrings = {
                confirmButtonLabel: "ok",
                text: alertText,
                title: alertTitle
            };

            var alertoptions = {
                heigth: 120,
                width: 200
            };

            Xrm.Navigation.openAlertDialog(alertStrings, alertoptions);
    } 
}


   
    
