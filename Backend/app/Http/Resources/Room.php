<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;

class Room extends JsonResource
{
    /**
     * Transform the resource into an array.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return array|\Illuminate\Contracts\Support\Arrayable|\JsonSerializable
     */
    public function toArray($request)
    {
        return [
            'room_id' => $this->room_id,
            'user_w' => $this->user_w,
            'user_b' => $this->user_b,
            'step_w' => $this->step_w,
            'step_b' => $this->step_b,
        ];
    }
}
