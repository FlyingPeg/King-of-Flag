<?php

namespace App\Http\Resources;

use Illuminate\Http\Resources\Json\JsonResource;
use App\Models\User;

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
        $user = DB::table('users')->where('id', $this->user_id)->first();
        return [
            'room_id' => $this->room_id,
            'user_id' => $this->user_id,
            'user_name' => $user->name,
            'step' => $this->step,
        ];
    }
}
