namespace DF.Entities
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// The user login entity.
    /// </summary>
    public class UserLogin
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [JsonProperty(PropertyName = "password")]
        public string password { get; set; }

        /// <summary>
        /// Gets or sets the phonePrefix.
        /// </summary>
        /// <value>
        /// The phonePrefix.
        /// </value>
        [JsonProperty(PropertyName = "phonePrefix")]
        public string phonePrefix { get; set; }

        /// <summary>
        /// Gets or sets the phoneNumber.
        /// </summary>
        /// <value>
        /// The phoneNumber.
        /// </value>
        [JsonProperty(PropertyName = "phoneNumber")]
        public string phoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the emulationPhone.
        /// </summary>
        /// <value>
        /// The emulationPhone.
        /// </value>
        [JsonProperty(PropertyName = "emulationPhone")]
        public string emulationPhone { get; set; }

        /// <summary>
        /// Gets or sets the latestTestDateBloodResults.
        /// </summary>
        /// <value>
        /// The latestTestDateBloodResults.
        /// </value>
        [JsonProperty(PropertyName = "latestTestDateBloodResults")]
        public string latestTestDateBloodResults { get; set; }

        /// <summary>
        /// Gets or sets the latestTestDateQuickPickUp.
        /// </summary>
        /// <value>
        /// The latestTestDateQuickPickUp.
        /// </value>
        [JsonProperty(PropertyName = "latestTestDateQuickPickUp")]
        public string latestTestDateQuickPickUp { get; set; }

        /// <summary>
        /// Gets or sets the latestTestValueQuickPickUp.
        /// </summary>
        /// <value>
        /// The latestTestValueQuickPickUp.
        /// </value>
        [JsonProperty(PropertyName = "latestTestValueQuickPickUp")]
        public string latestTestValueQuickPickUp { get; set; }

        /// <summary>
        /// Gets or sets the ReleaseDateHorizontal.
        /// </summary>
        /// <value>
        /// The ReleaseDateHorizontal.
        /// </value>
        [JsonProperty(PropertyName = "ReleaseDateHorizontal")]
        public List<string> ReleaseDateHorizontal { get; set; }

        /// <summary>
        /// Gets or sets the ReleaseDateVertical.
        /// </summary>
        /// <value>
        /// The ReleaseDateVertical.
        /// </value>
        [JsonProperty(PropertyName = "ReleaseDateVertical")]
        public List<string> ReleaseDateVertical { get; set; }

        /// <summary>
        /// Gets or sets the ReleaseDateVertical.
        /// </summary>
        /// <value>
        /// The ReleaseDateVertical.
        /// </value>
        [JsonProperty(PropertyName = "ReleaseResultVertical")]
        public List<string> ReleaseResultVertical { get; set; }

		/// <summary>
		/// Gets or sets the uuid.
		/// </summary>
		/// <value>
		/// The uuid.
		/// </value>
		[JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

		/// <summary>
		/// Gets or sets the hash.
		/// </summary>
		/// <value>
		/// The latestTestValueQuickPickUp.
		/// </valuehash
		[JsonProperty(PropertyName = "hash")]
		public string Hash { get; set; }

		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		/// <value>
		/// The gender.
		/// </value>
		[JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		/// <value>
		/// The city.
		/// </value>
		[JsonProperty(PropertyName = "city")]
        public string City { get; set; }

		/// <summary>
		/// Gets or sets the neighbourhood.
		/// </summary>
		/// <value>
		/// The neighbourhood.
		/// </value>
		[JsonProperty(PropertyName = "neighbourhood")]
        public string Neighbourhood { get; set; }

		/// <summary>
		/// Gets or sets the clinic.
		/// </summary>
		/// <value>
		/// The clinic.
		/// </value>
		[JsonProperty(PropertyName = "clinic")]
        public string Clinic { get; set; }

        /// <summary>
        /// Gets or sets the BarcodeIdList.
        /// </summary>
        /// <value>
        /// The BarcodeIdList.
        /// </value>
        [JsonProperty(PropertyName = "barcode_id")]
        public List<string> BarcodeIdList { get; set; }
    }
}