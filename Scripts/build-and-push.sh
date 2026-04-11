#!/usr/bin/env bash
set -euo pipefail

REGISTRY="ghcr.io"
USERNAME="faolanschaefer"
REPO_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"

# Image name -> Dockerfile directory (relative to repo root)
declare -A SERVICES=(
  ["carrental-gateway"]="CarRental.Gateway"
  ["carrental-mvc"]="CarRental.MVC"
  ["customerprofile-webapi"]="CustomerProfile.WebAPI"
  ["maintenance-webapi"]="Maintenance.WebAPI"
  ["vehicleinventory-webapi"]="VehicleInventory.WebAPI"
)

TAG="${1:-latest}"

echo "Building and pushing images to ${REGISTRY}/${USERNAME} with tag '${TAG}'"
echo "Repo root: ${REPO_ROOT}"
echo ""

for IMAGE_NAME in "${!SERVICES[@]}"; do
  SERVICE_DIR="${SERVICES[$IMAGE_NAME]}"
  FULL_IMAGE="${REGISTRY}/${USERNAME}/${IMAGE_NAME}:${TAG}"

  echo "==> Building ${FULL_IMAGE}"
  docker build \
    --file "${REPO_ROOT}/${SERVICE_DIR}/Dockerfile" \
    --tag "${FULL_IMAGE}" \
    "${REPO_ROOT}"

  echo "==> Pushing ${FULL_IMAGE}"
  docker push "${FULL_IMAGE}"

  echo ""
done

echo "Done."
