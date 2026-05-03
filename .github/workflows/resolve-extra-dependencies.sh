#!/bin/bash
set -euo pipefail

# install xmllint
sudo apt-get update -y
sudo apt-get install -y libxml2-utils

# define extra dependencies
LIBS=(
    "Xdr:xdr-net"
    "LibvirtModel:libvirt-schema-net"
    "LibvirtRemote:libvirt-remote-net"
    "LibvirtHeader:libvirt-header-net"
)

# create local package directory
mkdir -p "${LOCALPKG}"

# doenload extra dependencies
while read -r PROJECT
do
    for LIB in "${LIBS[@]}"
    do
        VERION=$(xmllint --xpath "string(//PackageReference[@Include='${LIB%:*}']/@Version)" "${PROJECT}")
        if [ -n "${VERION}" ]; then
            FILE_NAME="${LIB%:*}.${VERION}.nupkg"
            if [[ ! -f "${LOCALPKG}/${FILE_NAME}" ]]; then
                curl -fsSLO --output-dir "${LOCALPKG}" --url "https://github.com/9506hqwy/${LIB#*:}/releases/download/${VERION}/${FILE_NAME}"
            fi
        fi
    done
done < <(find . -name "*.csproj")

# download transitive dependencies
curl -fsSLO --output-dir "${LOCALPKG}" --url "https://github.com/9506hqwy/xdr-net/releases/download/0.4.0/Xdr.0.4.0.nupkg"
