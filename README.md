# DOC generator CLI

# Resumo
Doc generator é um mini CLI baseado no pacote commander. Foi desenvolvido para
gerar imagens, CPF e CNPJS para fins de teste durante o desenvolvimento de serviços de autenticação.

Esse projeto é para fins de testes. E não deve ser usado para qualquer ato ilícito, uso indevido da ferramenta, ou trapaças.

# Exemplos

### Gerar 3 imagens com base64 e com um tamanho específico.

> doc --count 3  --base64 --width 600 height 600

### Gerar 3 imagens sem base 64, com campos de categoriaDocumento 1,2,3

> doc --count 3 --categoria 1,2,3

### Comandos

--forceCPF         Forçar uso de CPF

  --forceCNPJ        Forçar uso de CNPJ

  --cpfcnpj          Forçar uso de um CPFCNPJ específico

  --count            Quantidade de imagens

  -c, --categoria    Gerar log com campo CategoriaDocumento

  -b, --base64       Gerar log com  Base64 da imagem

  -w, --width        Largura

  -h, --height       Altura
